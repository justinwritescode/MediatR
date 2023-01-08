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

namespace JustinWritesCode.MediatR.Commands;
#if NETSTANDARD2_0_OR_GREATER
using Microsoft.AspNetCore.JsonPatch;

public record struct PatchCommand<TId, TPatchDto, TDto>(JsonPatchDocument<TDto> Patch, TId Id) : IPatchCommand<TId, TPatchDto, TDto>
    where TId : IComparable, IEquatable<TId>
    where TDto : class
{
    // public PatchCommand(JsonPatchDocument patch, TId id)
    // {
    //     Patch = patch;
    //     Id = id;
    // }

    public JsonPatchDocument<TDto> Patch { get; init; } = Patch;
    public TId Id { get; init; } = Id;
}
#endif
