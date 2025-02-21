﻿using System;
using System.IO;
using System.Linq;
using Symbolica.Implementation.System;

namespace Symbolica.Application.Implementation
{
    internal sealed class DirectoryProxy : IDirectory
    {
        private readonly DirectoryInfo _directory;

        public DirectoryProxy(DirectoryInfo directory)
        {
            _directory = directory;
        }

        public long LastAccessTime => new DateTimeOffset(_directory.LastAccessTimeUtc).ToUnixTimeSeconds();
        public long LastModifiedTime => new DateTimeOffset(_directory.LastWriteTimeUtc).ToUnixTimeSeconds();

        public string[] GetNames()
        {
            return _directory.EnumerateFileSystemInfos()
                .Select(i => i.Name)
                .Append(".")
                .Append("..")
                .ToArray();
        }
    }
}
