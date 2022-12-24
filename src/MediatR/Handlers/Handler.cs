/*
 * Handler.cs
 *
 *   Created: 2022-12-21-10:51:28
 *   Modified: 2022-12-21-10:51:28
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR;

using System.Linq.Expressions;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.QueryableExtensions;
using JustinWritesCode.MediatR.Handlers.Abstractions;

public class CrudHandler<TModel, TInsertDto, TUpdateDto, TViewDto, TDbContext, TId>
    : IHaveADbContext<TDbContext>,
        ICreateHandler<CreateCommand<TId, TInsertDto, TViewDto>, TId, TInsertDto, TViewDto>,
        IUpdateHandler<UpdateCommand<TModel, TId, TUpdateDto, TViewDto>, TId, TModel, TUpdateDto, TViewDto>,
        IDeleteHandler<DeleteCommand<TId>, TId>,
        IDeleteHandler<DeleteCommand<TId, TViewDto>, TId, TViewDto>,
        IQueryHandler<Query<TId, TViewDto>, TId, TViewDto>,
        IQueryHandler<Query<TViewDto>, TViewDto>
    where TDbContext : DbContext, IDbContext<TDbContext>
    where TModel : class, IIdentifiable<TId>
    where TId : IComparable, IEquatable<TId>
    where TViewDto : IIdentifiable<TId>
{
    public virtual IMediator Mediator { get; }
    public virtual TDbContext Db { get; }
    public virtual IMapper Mapper { get; }
    IDbContext DbContext => Db;

    DbContext IHaveADbContext.Db => throw new NotImplementedException();

    public CrudHandler(IMediator mediator, TDbContext dbContext, IMapper mapper)
    {
        Mediator = mediator;
        Db = dbContext;
        Mapper = mapper;
    }

    public async Task<TViewDto> Handle(CreateCommand<TId, TInsertDto, TViewDto> request, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<TModel>(request.Create);
        Db.Set<TModel>().Add(model);
        await Db.SaveChangesAsync();
        var dto = Mapper.Map<TViewDto>(model);
        await Mediator.Publish(new CreatedNotification<TId, TInsertDto, TViewDto>(model.Id, dto), cancellationToken);
        return dto;
    }
    public Task<TViewDto> Handle(UpdateCommand<TModel, TId, TUpdateDto, TViewDto> request, CancellationToken cancellationToken)
    {
        var model = Db.Set<TModel>().Find(request.Update);
        Mapper.Map(request.Update, model);
        Db.Set<TModel>().Update(model);
        Db.SaveChanges();
        var dto = Mapper.Map<TViewDto>(model);
        Mediator.Publish(new UpdatedNotification<TViewDto>(dto), cancellationToken);
        return Task.FromResult(dto);
    }
    public Task<Unit> Handle(DeleteCommand<TId> request, CancellationToken cancellationToken)
    {
        var model = Db.Set<TModel>().Find(request.Id);
        Db.Set<TModel>().Remove(model);
        Db.SaveChanges();
        var dto = Mapper.Map<TViewDto>(model);
        Mediator.Publish(new DeletedNotification<TId, TViewDto>(dto, request.Id), cancellationToken);
        return Task.FromResult(Unit.Value);
    }
    public Task<Unit> Handle(DeleteCommand<TId, TViewDto> request, CancellationToken cancellationToken)
    {
        if(!request.Id.Equals(request.Dto.Id))
            throw new ArgumentException("The Id and Dto.Id must match.");

        var model = Db.Set<TModel>().Find(request.Id);
        Db.Set<TModel>().Remove(model);
        Db.SaveChanges();
        var dto = Mapper.Map<TViewDto>(model);
        Mediator.Publish(new DeletedNotification<TId, TViewDto>(dto, request.Id), cancellationToken);
        return Task.FromResult(Unit.Value);
    }
    public Task<TViewDto> Handle(Query<TId, TViewDto> request, CancellationToken cancellationToken)
    {
        var model = Db.Set<TModel>().FirstOrDefault(Mapper.MapExpression<Expression<Func<TViewDto, bool>>, Expression <Func<TModel, bool> >>(request.Predicate));
        if(model is null)
            throw new KeyNotFoundException($"A(n) {typeof(TModel).Name} meeting the requested criteria was not found.");
        var dto = Mapper.Map<TViewDto>(model);
        return Task.FromResult(dto);
    }
    public async Task<IEnumerable<TViewDto>> Handle(Query<TViewDto> request, CancellationToken cancellationToken)
        => await Db.Set<TModel>()
                   .Where(Mapper.MapExpression<Expression<Func<TViewDto, bool>>, Expression<Func<TModel, bool>>>(request.Predicate))
                   .ProjectTo<TViewDto>(Mapper.ConfigurationProvider)
                   .ToListAsync();
}
