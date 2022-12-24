/*
 * IQueryHandler.cs
 *
 *   Created: 2022-12-21-10:49:58
 *   Modified: 2022-12-21-10:49:58
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using JustinWritesCode.MediatR.Abstractions;
using JustinWritesCode.Abstractions;

namespace JustinWritesCode.MediatR.Handlers.Abstractions;

public interface IQueryHandler<TQuery, TId, TDto> : IRequestHandler<TQuery, TDto>
    where TQuery : IQuery<TId, TDto>
    where TId : IComparable, IEquatable<TId>
    where TDto : IIdentifiable<TId>
{

}
public interface IQueryHandler<TQuery, TDto> : IRequestHandler<TQuery, IEnumerable<TDto>>
    where TQuery : IQuery<TDto>
{

}
