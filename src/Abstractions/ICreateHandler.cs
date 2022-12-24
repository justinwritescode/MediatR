/*
 * ICreateHandler.cs
 *
 *   Created: 2022-12-21-10:42:55
 *   Modified: 2022-12-21-10:42:56
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Reflection;
using JustinWritesCode.MediatR.Abstractions;

namespace JustinWritesCode.MediatR.Handlers.Abstractions;

public interface ICreateHandler<TCreateCommand, TId, TCreateDto, TDto> : IRequestHandler<TCreateCommand, TDto>
    where TId : IComparable, IEquatable<TId>
    where TCreateCommand : ICreateCommand<TId, TCreateDto, TDto>
{

}
