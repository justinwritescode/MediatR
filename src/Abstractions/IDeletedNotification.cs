/*
 * IDeletedNotification.cs
 *
 *   Created: 2022-12-21-10:32:34
 *   Modified: 2022-12-21-10:32:47
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Abstractions;

public interface IDeletedNotification<TId, TDto> : INotification
    where TId : IComparable, IEquatable<TId>
{

}

public interface IDeletedNotification<TId> : INotification
    where TId : IComparable, IEquatable<TId>
{

}
