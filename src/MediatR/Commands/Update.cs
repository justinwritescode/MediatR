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

namespace JustinWritesCode.MediatR.Commands;

public record struct UpdateCommand<TModel, TId, TUpdateDto, TDto>(TUpdateDto Update) : IUpdateCommand<TModel, TId, TUpdateDto, TDto>
    where TModel : class, IIdentifiable<TId>
    where TId : IComparable, IEquatable<TId>
{
    // public UpdateCommand(TUpdateDto updateDto)
    // {
    //     Update = updateDto;
    // }

    public TUpdateDto Update { get; init; } = Update;
}
