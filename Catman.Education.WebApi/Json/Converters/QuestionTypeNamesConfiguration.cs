namespace Catman.Education.WebApi.Json.Converters
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.WebApi.DataTransferObjects.Questions.Question;
    using Catman.Education.WebApi.DataTransferObjects.Testing;
    using Catman.Education.WebApi.DataTransferObjects.Testing.Answered;

    /// <summary> Encapsulates the registration and retrieval logic of a question type </summary>
    /// <remarks>
    ///     The static class was chosen over singleton because services cannot be injected into the JsonConverter
    /// </remarks>
    internal static class QuestionTypeNamesConfiguration
    {
        private static readonly IDictionary<string, Type> TypeNameToAnsweredType = new Dictionary<string, Type>();
        private static readonly IDictionary<Type, string> TypeToTypeName = new Dictionary<Type, string>();

        public static void RegisterQuestion<TDto, TFullyPopulatedDto, TTestingDto, TAnsweredDto>()
            where TDto : QuestionDto
            where TTestingDto : TestingQuestionDto
            where TAnsweredDto : AnsweredQuestionDto
        {
            var typeName = typeof(TDto).Name.Replace("QuestionDto", string.Empty);

            TypeNameToAnsweredType[typeName] = typeof(TAnsweredDto);

            TypeToTypeName[typeof(TDto)] = typeName;
            TypeToTypeName[typeof(TFullyPopulatedDto)] = typeName;
            TypeToTypeName[typeof(TTestingDto)] = typeName;
        }

        public static bool IsSupportedQuestion(Type questionType) =>
            TypeToTypeName.ContainsKey(questionType);

        public static string QuestionTypeName(object question)
        {
            var questionType = question.GetType();
            if (!TypeToTypeName.ContainsKey(questionType))
            {
                throw new Exception($"Unknown question type \"{questionType.Name}\".");
            }

            return TypeToTypeName[questionType];
        }

        public static Type QuestionType(string typeName)
        {
            if (!TypeNameToAnsweredType.ContainsKey(typeName))
            {
                throw new Exception($"Unknown question type \"{typeName}\".");
            }

            return TypeNameToAnsweredType[typeName];
        }
    }
}
