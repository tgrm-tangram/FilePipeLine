using System;
using System.Collections.Generic;
using System.IO;

namespace FilePipeLine
{
    /** 传送模式 */
    public enum TransmitModel
    {
        LINE,   // 单行传输
        //FILE,   // 文件传输
        //LINES   // 多行传输 按文件
    }

    /** 分拣器 */
    public interface ISorter
    {
         
    }

    /** 打标签器 */
    public interface ITagEditor
    {
        string Tag();
    }

    /** 收集器 */
    public interface ICollector
    {
        void Collect(Action<string[], bool, string> action);
    }

    /** 加工器 */
    public interface IProcessor
    {
        /** 过滤 
         * returns 如果为 true 会被过滤      
         */
        bool Filter(string[] line);

        /** 加工 */
        string[] Process(string[] line);
    }

    /** 输出器 */
    public interface IOutputer
    {
        /** 开始 */
        void Start();

        /** 开始传输 */
        void FileStart(string fileName);

        /** 输出 */
        void Output(IPackage package, string fileName);

        /** 文件结束 */
        void FileEnd(string fileName);

        /** 全部结束 */
        void Finish();
    }

    /** 包裹 */
    public interface IPackage
    {
        /** 读取 */
        string[] ReadLine();

        /** 标签 */
        void SetTag(string tag);

        /** 标签 */
        string Tag();
    }

    /** 构造器 */
    public interface IBuilder
    {
        /** 设置收集器 */
        IBuilder SetCollector(ICollector collector);

        /** 设置输出器 */
        IBuilder SetOutputer(IOutputer outputer);

        /** 装配加工器 */
        IBuilder Assemble(IProcessor processor);

        /** 传送模式 */
        IBuilder Model(TransmitModel model);

        /** 构建流水线 */
        IPipeLine Build();
    }

    /** 流水线 */
    public interface IPipeLine
    {
        /** 运行加工流水线 */
        IOutputer Run();
    }
}
