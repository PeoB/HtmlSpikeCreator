using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using HtmlSpikeCreator.Extensions;

namespace HtmlSpikeCreator
{
    
    public class HtmlFactory : DynamicObject
    {
        private HtmlFactory(){}
        public static dynamic CreateHtmlFactory()
        {
            return new HtmlFactory();
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var attributes = GenerateAttributes(args, binder.CallInfo.ArgumentNames);
            var contents = GenerateContents(args.Take(args.Length - attributes.Count));
            var htmlElement = new HtmlElement(binder.Name, contents, attributes);

            result = htmlElement;
            return true;
        }

        private static string GenerateContents(IEnumerable<object> contents)
        {
            return contents
                .Select(o => o.ToString())
                .Concat();
        }

        private static IDictionary<string, string> GenerateAttributes(object[] args, ICollection<string> attrNames)
        {
            return
                args.Skip(args.Count() - attrNames.Count())
                    .Zip(attrNames, (o, s) => new { k = s, v = o.ToString() })
                    .ToDictionary(arg => arg.k, arg => arg.v);
        }
    }

    public class HtmlElement
    {
        public string Name { get; set; }
        public string Contents { get; set; }
        public IDictionary<string, string> Attributes { get; set; }

        public HtmlElement(string name, string contents, IDictionary<string, string> attributes)
        {
            Name = name.TrimStart('@');
            Contents = contents;
            Attributes = attributes;
        }
        private string AttrStr
        {
            get
            {
                return
                    Attributes
                        .Select(pair => string.Format(" {0}=\"{1}\"", pair.Key, pair.Value))
                        .Concat();
            }
        }
        public override string ToString()
        {
            return string.Format("<{0}{1}>{2}</{0}>", Name, AttrStr,Contents);
        }
    }
}
