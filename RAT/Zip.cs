﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace RAT
{
    class Zip
    {
        public static void Unzip(string file)
        {
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(file))) {
		
			ZipEntry theEntry;
			while ((theEntry = s.GetNextEntry()) != null) {
				
				Console.WriteLine(theEntry.Name);
				
				string directoryName = Path.GetDirectoryName(theEntry.Name);
				string fileName      = Path.GetFileName(theEntry.Name);
				
				// create directory
				if ( directoryName.Length > 0 ) {
					Directory.CreateDirectory(directoryName);
				}
				
				if (fileName != String.Empty) {
					using (FileStream streamWriter = File.Create(theEntry.Name)) {
					
						int size = 2048;
						byte[] data = new byte[2048];
						while (true) {
							size = s.Read(data, 0, data.Length);
							if (size > 0) {
								streamWriter.Write(data, 0, size);
							} else {
								break;
							}
						}
					}
				}
			}
		}
        }
    }
}
