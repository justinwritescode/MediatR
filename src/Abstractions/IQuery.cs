/*
 * IQuery.cs
 *
 *   Created: 2022-12-21-10:07:40
 *   Modified: 2022-12-21-10:08:05
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Linq.Expressions;
using JustinWritesCode.Abstractions;

namespace JustinWritesCode.MediatR.Abstractions;

public interface IQuery<TId, TDto> : IQueryBase<TDto>, IRequest<TDto>
    where TId : IComparable, IEquatable<TId>
    where TDto : IIdentifiable<TId>
{
}

public interface IQuery<TDto> : IQueryBase<TDto>, IRequest<IEnumerable<TDto>>
{
    int PageSize { get; }
    int PageNumber { get; }
}

public interface IQueryBase<TDto>
{
    Expression<Func<TDto, bool>>? Predicate { get; }
}
