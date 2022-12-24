/*
 * Create.cs
 *
 *   Created: 2022-12-21-09:48:41
 *   Modified: 2022-12-21-10:11:46
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Notifications;
using JustinWritesCode.MediatR.Abstractions;

public class CreatedNotification<TId, TCreateDto, TDto> : ICreatedNotification<TId, TDto, TCreateDto>
    where TId : IComparable, IEquatable<TId>
{
    public CreatedNotification() { }
    public CreatedNotification(TDto dto) => Created = dto;
    public CreatedNotification(TId id, TDto dto) => Created = dto;
    public TDto Created { get; set; }
}
