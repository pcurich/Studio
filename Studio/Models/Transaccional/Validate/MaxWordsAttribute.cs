using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Studio.Models.Transaccional.Validate
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public int MaxWords { get; set; }

        public MaxWordsAttribute(int maxWords)
            : base(" Muchas palabras en {0}")
        {
            MaxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var wordCount = value.ToString().Split(' ').Length;
                if (wordCount > MaxWords)
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", MaxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }

        //<input
        //    data-val="true"
        //    data-val-length="The field Title must be a string with a maximum length of 160."
        //    data-val-length-max="160"
        //    data-val-maxwords=" Muchas palabras en Title"
        //    data-val-maxwords-wordcount="10"
        //    data-val-required="An Album Title is required" id="Title" name="Title"
        //    type="text" value="For Those About To Rock We Salute You" />
    }
}