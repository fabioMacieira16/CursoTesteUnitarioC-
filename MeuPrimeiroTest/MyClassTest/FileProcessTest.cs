using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClass;
using System;
using System.Configuration;
using System.IO;

namespace MyClassTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\windows\Regedit.exe";
        private string _GoodFileName;

        [TestMethod]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromcall;

            setGoodFileName();

            File.AppendAllText(_GoodFileName, "Some Text");
            fromcall = fp.FileExists(_GoodFileName);
            File.Delete(_GoodFileName);

            Assert.IsTrue(fromcall);
        }

        public void setGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                   Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromcall;

            fromcall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromcall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_ThrowsArgumetNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_ThrowsArgumetNullException_TryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                fp.FileExists("");

            }
            catch (ArgumentException)
            {

                return;
            }

            Assert.Fail("Fail excpectd");
        }

    }
}
