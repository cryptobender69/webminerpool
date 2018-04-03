﻿// The MIT License (MIT)

// Copyright (c) 2018 - the webminerpool developer

// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Server {

	public class Helper {
		public static void WriteTextAsyncWrapper (string filePath, string text, FileMode fileMode = FileMode.Append) {
			#pragma warning disable 4014
			WriteTextAsync (filePath, text, fileMode);
			#pragma warning restore 4014
		}

		public static async Task WriteTextAsync (string filePath, string text, FileMode fileMode = FileMode.Append) {
			byte[] encodedText = Encoding.ASCII.GetBytes (text);

			using (FileStream sourceStream = new FileStream (filePath,
				fileMode, FileAccess.Write, FileShare.None,
				bufferSize : 4096, useAsync : true)) {
				await sourceStream.WriteAsync (encodedText, 0, encodedText.Length);
			};
		}

	}
}
