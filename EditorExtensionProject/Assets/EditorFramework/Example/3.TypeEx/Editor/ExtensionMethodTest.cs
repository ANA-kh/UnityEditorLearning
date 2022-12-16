using NUnit.Framework;
namespace EditorFramework
{
    public class ExtensionMethodTest
    {
        [Test]
        public static void TestExtensionMethond()
        {
            var myStruct = new ExtensionFuncTest();
            myStruct.x = 10;
            var newStruct = myStruct.ChangeX(20); //成员函数，会改变myStruct的值。 但返回值是按值传递，newStruct不是myStruct
            newStruct.x = 21;
            var newStruct2 = myStruct.ChangeXEX(30); //扩展函数，this参数按值传递，不会改变myStruct的值
            newStruct2.x = 31;
        }
    }
    
    public static class ExtensionFuncTestExtension
    {
        public static ExtensionFuncTest ChangeXEX(this ExtensionFuncTest self, int x)
        {
            self.x = x;
            return self;
        }
    }
    
    public struct ExtensionFuncTest
    {
        public int x;
        public ExtensionFuncTest ChangeX(int x)
        {
            this.x = x;
            return this;
        }
    }
}