/*
 * DeleteCommand.cs
 *
 *   Created: 2022-12-21-10:01:23
 *   Modified: 2022-12-21-10:02:34
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Abstractions;

public interface IDeleteCommand<TId, TDto> : IDeleteCommand<TId>
    where TId : IComparable, IEquatable<TId>
{

}

public interface IDeleteCommand<TId> : ICommand<Unit>
    where TId : IComparable, IEquatable<TId>
{

}
