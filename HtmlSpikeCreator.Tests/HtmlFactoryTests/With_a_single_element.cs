using NUnit.Framework;

namespace HtmlSpikeCreator.Tests.HtmlFactoryTests
{
    public class With_a_single_empty_element
    {
        private dynamic _ = HtmlFactory.CreateHtmlFactory();

        [Test]
        public void It_should_return_an_html_string_with_the_document()
        {
            var html = _.html().ToString();
            const string expected = "<html></html>";
            Assert.AreEqual(expected, html);
        }
    }
}