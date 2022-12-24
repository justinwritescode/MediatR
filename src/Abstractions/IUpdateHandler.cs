/*
 * IUpdateHandler.cs
 *
 *   Created: 2022-12-21-10:45:59
 *   Modified: 2022-12-21-10:46:10
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using JustinWritesCode.Abstractions;
using JustinWritesCode.MediatR.Abstractions;

namespace JustinWritesCode.MediatR.Handlers.Abstractions;

public interface IUpdateHandler<TUpdateCommand, TId, TModel, TUpdateDto, TDto> : IRequestHandler<TUpdateCommand, TDto>
    where TUpdateCommand : IUpdateCommand<TModel, TId, TUpdateDto, TDto>
    where TModel : class, IIdentifiable<TId>
    where TId : IComparable, IEquatable<TId>
{

}
