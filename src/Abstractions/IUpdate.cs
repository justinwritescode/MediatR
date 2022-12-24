/*
 * IUpdateCommand.cs
 *
 *   Created: 2022-12-21-10:01:45
 *   Modified: 2022-12-21-10:02:43
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Abstractions;
using JustinWritesCode.Abstractions;

public interface IUpdateCommand<TModel, TId, TUpdateDto, TDto> : ICommand<TDto>
    where TModel : class, IIdentifiable<TId>
    where TId : IComparable, IEquatable<TId>
{

}
