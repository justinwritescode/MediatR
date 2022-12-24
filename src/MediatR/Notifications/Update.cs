/*
 * IUpdatedNotification.cs
 *
 *   Created: 2022-12-21-10:01:45
 *   Modified: 2022-12-21-10:02:43
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.MediatR.Notifications;

public class UpdatedNotification<TDto> : IUpdatedNotification<TDto>
{
    public UpdatedNotification(TDto updateDto)
    {
        Updated = updateDto;
    }

    public TDto Updated { get; set; }
}
