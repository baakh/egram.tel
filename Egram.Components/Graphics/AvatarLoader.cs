﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Egram.Components.Persistence;
using Egram.Components.TDLib;

namespace Egram.Components.Chatting
{
    public class AvatarLoader
    {
        private readonly FileLoader _fileLoader;

        public AvatarLoader(FileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }
        
        public async Task<IBitmap> LoadForUserAsync(TD.User user)
        {
            var localFile = await _fileLoader.LoadFileAsync(user.ProfilePhoto?.Small);

            if (localFile?.Path != null)
            {
                return new Bitmap(localFile.Path);
            }

            return null;
        }

        public async Task<IBitmap> LoadForChatAsync(TD.Chat chat)
        {   
            var localFile = await _fileLoader.LoadFileAsync(chat.Photo?.Small);

            if (localFile?.Path != null)
            {
                return new Bitmap(localFile.Path);
            }

            return null;
        }
    }
}