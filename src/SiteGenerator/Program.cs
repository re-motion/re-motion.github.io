// SPDX-License-Identifier: LGPL-2.1-or-later
// SPDX-FileCopyrightText: 2022 RUBICON IT GmbH, www.rubicon.eu

using System;

namespace SiteGenerator;

public class Program
{
  public static async Task<int> Main (string[] args) =>
      await Bootstrapper
          .Factory
          .CreateDefault (args)
          .RunAsync();
}