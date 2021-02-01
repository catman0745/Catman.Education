namespace Catman.Education.Application.Features.Testing.Commands.CheckTest.QuestionCheckers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Models.Answered;
    using Catman.Education.Application.Models.Checked;

    internal class QuestionChecker
    {
        public static QuestionCheckResult CheckQuestion(Question question, AnsweredQuestion answeredQuestion) =>
            GetQuestionChecker(question.GetType(), answeredQuestion.GetType())
                .Check(question, answeredQuestion);

        private static IQuestionChecker GetQuestionChecker(Type questionType, Type answeredQuestionType)
        {
            var questionCheckerTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => IsQuestionCheckerType(type) && !type.IsAbstract);

            var questionCheckerType = questionCheckerTypes
                .First(checkerType => checkerType.BaseType!.GetGenericArguments()[0] == questionType &&
                                      checkerType.BaseType!.GetGenericArguments()[1] == answeredQuestionType);

            return (IQuestionChecker)Activator.CreateInstance(questionCheckerType);
        }

        private static bool IsQuestionCheckerType(Type type)
        {
            // The type.IsSubclassOf (typeof (QuestionCheckerBase <,>)) way cannot be used because we actually don't
            // know what types the generic types have been replaced with.
            
            // Thus, we need to check the inheritance sequence and find QuestionCheckerBase <,>.
            
            while (type != null && type != typeof(object))
            {
                if (typeof(QuestionCheckerBase<,>) == (type.IsGenericType ? type.GetGenericTypeDefinition() : type))
                {
                    return true;
                }
			
                type = type.BaseType;
            }
            return false;
        }
    }
}
