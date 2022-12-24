/*
 * IDeleteHandler.cs
 *
 *   Created: 2022-12-21-11:45:44
 *   Modified: 2022-12-21-11:45:58
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using JustinWritesCode.MediatR.Abstractions;

namespace JustinWritesCode.MediatR.Handlers.Abstractions;

public interface IDeleteHandler<TDeleteCommand, TId, TDto> : IDeleteHandler<TDeleteCommand, TId>
    where TId : IComparable, IEquatable<TId>
    where TDeleteCommand : IDeleteCommand<TId, TDto>
{

}

public interface IDeleteHandler<TDeleteCommand, TId> : IRequestHandler<TDeleteCommand, Unit>
    where TId : IComparable, IEquatable<TId>
    where TDeleteCommand : IDeleteCommand<TId>
{

}
