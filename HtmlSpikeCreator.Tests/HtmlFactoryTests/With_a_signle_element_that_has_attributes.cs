using NUnit.Framework;

namespace HtmlSpikeCreator.Tests.HtmlFactoryTests
{
    public class With_elements_that_has_attributes
    {
        private dynamic _ = HtmlFactory.CreateHtmlFactory();
        [Test]
        public void It_should_return_an_html_string_with_the_document()
        {
            var html =
                _.html(
                    _.body(@class: "myClass"),
                    lang: "en")
                 .ToString();
            const string expected = "<html lang=\"en\"><body class=\"myClass\"></body></html>";
            Assert.AreEqual(expected, html);
        }
    }
}