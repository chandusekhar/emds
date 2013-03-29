System.InvalidOperationException: Стек пуст.
   в System.Collections.Generic.Stack`1.Pop()
   в ..( table,  simulationData, Int32 start, Int32 end, Stack`1 stack)
   в ..( instructionTable,  simulationData, Int32 startBlock, Stack`1 startStack,  blockLinkageInfo, Dictionary`2 result)
   в ..( table,  simulationData,  blockLinkageInfo)
   в ..( table,  simulationData, IExceptionHandler[] handlers)
   в ..(IMethodDeclaration mD, IMethodBody mB, Boolean handleExpressionStack)
   в ..(IMethodDeclaration mD, IMethodBody mB)
   в ..(IMethodDeclaration value)
   в ..(IMethodDeclarationCollection methods)
   в ..(ITypeDeclaration value)
   в ..TranslateTypeDeclaration(ITypeDeclaration value, Boolean memberDeclarationList, Boolean methodDeclarationBody)
   в ..(ITypeDeclaration typeDeclaration, String sourceFile, ILanguageWriterConfiguration languageWriterConfiguration)
namespace Encog.Engine.Network.Activation
{
}

