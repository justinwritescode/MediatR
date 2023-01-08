/*
 * ICommand.cs
 *
 *   Created: 2022-12-21-09:57:16
 *   Modified: 2022-12-21-09:57:16
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace JustinWritesCode.MediatR.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse> { }
