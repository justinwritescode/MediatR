/*
 * CreateHandler.cs
 *
 *   Created: 2022-12-26-10:53:57
 *   Modified: 2022-12-26-10:54:14
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR;

using JustinWritesCode.MediatR.Handlers.Abstractions;

public class CreateHAndler<TModel, TDbContext, TInsertDto, TViewDto, TId>
    : IHaveADbContext<TDbContext>,
        ICreateHandler<CreateCommand<TId, TInsertDto, TViewDto>, TId, TInsertDto, TViewDto>
    where TDbContext : DbContext, IDbContext<TDbContext>
    where TModel : class, IIdentifiable<TId>
    where TId : IComparable, IEquatable<TId>
    where TViewDto : IIdentifiable<TId>
{
    public virtual IMediator Mediator { get; }
    public virtual TDbContext Db { get; }
    public virtual IMapper Mapper { get; }
    IDbContext IHaveADbContext.Db => throw new NotImplementedException();

    public CreateHAndler(IMediator mediator, TDbContext dbContext, IMapper mapper)
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
}
