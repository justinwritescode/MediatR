using System.Net.Http.Headers;
/*
 * ICreateCommand.cs
 *
 *   Created: 2022-12-21-09:49:48
 *   Modified: 2022-12-21-09:49:48
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Abstractions;

public interface ICreateCommand<TId, TCreateDto, TDto> : ICommand<TDto>
    where TId : IComparable, IEquatable<TId>
{
}
