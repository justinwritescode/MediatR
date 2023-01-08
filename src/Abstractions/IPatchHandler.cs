/*
 * IPatchHandler.cs
 *
 *   Created: 2022-12-21-10:47:51
 *   Modified: 2022-12-21-10:48:09
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using JustinWritesCode.MediatR.Abstractions;

namespace JustinWritesCode.MediatR.Handlers.Abstractions;

public interface IPatchHandler<TPatchCommand, TId, TPatchDto, TDto> : IRequestHandler<TPatchCommand, TDto>
    where TPatchCommand : IPatchCommand<TId, TPatchDto, TDto>
    where TId : IComparable, IEquatable<TId>
{

}
