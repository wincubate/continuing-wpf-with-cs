namespace ConverterFun
{
    struct TranslationElement
    {
        public static TranslationElement English => new TranslationElement { Yes = "Yes", No = "No" };

        public string Yes { get; set; }
        public string No { get; set; }
    }
}
