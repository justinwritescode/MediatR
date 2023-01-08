/*
 * IPatchCommand
 *
 *   Created: 2022-12-21-10:02:09
 *   Modified: 2022-12-21-10:02:09
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Abstractions;

public interface IPatchCommand<TId, TPatchDto, TDto> : ICommand<TDto>
    where TId : IComparable, IEquatable<TId>
{

}
