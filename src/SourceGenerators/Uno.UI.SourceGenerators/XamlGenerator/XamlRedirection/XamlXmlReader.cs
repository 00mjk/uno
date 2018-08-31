﻿#if !NETSTANDARD2_0
extern alias __ms;
#endif
extern alias __uno;

using System;
using System.Xml;

namespace Uno.UI.SourceGenerators.XamlGenerator.XamlRedirection
{
	internal class XamlXmlReader : IDisposable
	{
		private XmlReader document;
		private XamlSchemaContext context;
		private XamlXmlReaderSettings settings;

#if !NETSTANDARD2_0
		private __ms::System.Xaml.XamlXmlReader _systemReader;
#endif
		private __uno::Uno.Xaml.XamlXmlReader _unoReader;

		public XamlXmlReader(XmlReader document, XamlSchemaContext context, XamlXmlReaderSettings settings)
		{
			this.document = document;
			this.context = context;
			this.settings = settings;

			if(XamlConfig.IsUnoXaml)
			{
				_unoReader = new __uno::Uno.Xaml.XamlXmlReader(document, context.UnoInner, settings.UnoInner);
			}
#if !NETSTANDARD2_0
			else
			{
				_systemReader = new __ms::System.Xaml.XamlXmlReader(document, context.MsInner, settings.MsInner);
			}
#endif
		}

#if !NETSTANDARD2_0
		public XamlNodeType NodeType => XamlConfig.IsUnoXaml ? Convert(_unoReader.NodeType) : Convert(_systemReader.NodeType);
#else
		public XamlNodeType NodeType => Convert(_unoReader.NodeType);
#endif

#if !NETSTANDARD2_0
		private XamlNodeType Convert(__ms::System.Xaml.XamlNodeType source)
		{
			switch (source)
			{
				default:
				case __ms::System.Xaml.XamlNodeType.None:
					return XamlNodeType.None;
				case __ms::System.Xaml.XamlNodeType.StartObject:
					return XamlNodeType.StartObject;
				case __ms::System.Xaml.XamlNodeType.GetObject:
					return XamlNodeType.GetObject;
				case __ms::System.Xaml.XamlNodeType.EndObject:
					return XamlNodeType.EndObject;
				case __ms::System.Xaml.XamlNodeType.StartMember:
					return XamlNodeType.StartMember;
				case __ms::System.Xaml.XamlNodeType.EndMember:
					return XamlNodeType.EndMember;
				case __ms::System.Xaml.XamlNodeType.Value:
					return XamlNodeType.Value;
				case __ms::System.Xaml.XamlNodeType.NamespaceDeclaration:
					return XamlNodeType.NamespaceDeclaration;
			}
		}
#endif

		private XamlNodeType Convert(__uno::Uno.Xaml.XamlNodeType source)
		{
			switch (source)
			{
				default:
				case __uno::Uno.Xaml.XamlNodeType.None:
					return XamlNodeType.None;
				case __uno::Uno.Xaml.XamlNodeType.StartObject:
					return XamlNodeType.StartObject;
				case __uno::Uno.Xaml.XamlNodeType.GetObject:
					return XamlNodeType.GetObject;
				case __uno::Uno.Xaml.XamlNodeType.EndObject:
					return XamlNodeType.EndObject;
				case __uno::Uno.Xaml.XamlNodeType.StartMember:
					return XamlNodeType.StartMember;
				case __uno::Uno.Xaml.XamlNodeType.EndMember:
					return XamlNodeType.EndMember;
				case __uno::Uno.Xaml.XamlNodeType.Value:
					return XamlNodeType.Value;
				case __uno::Uno.Xaml.XamlNodeType.NamespaceDeclaration:
					return XamlNodeType.NamespaceDeclaration;
			}
		}

#if !NETSTANDARD2_0
		public object Value => XamlConfig.IsUnoXaml ? _unoReader.Value : _systemReader.Value;

		public XamlType Type => XamlConfig.IsUnoXaml ? XamlType.FromType(_unoReader.Type) : XamlType.FromType(_systemReader.Type);

		public int LineNumber => XamlConfig.IsUnoXaml ? _unoReader.LineNumber : _systemReader.LineNumber;

		public int LinePosition => XamlConfig.IsUnoXaml ? _unoReader.LinePosition : _systemReader.LinePosition;

		public XamlMember Member => XamlConfig.IsUnoXaml ? XamlMember.FromMember(_unoReader.Member) : XamlMember.FromMember(_systemReader.Member);

		public NamespaceDeclaration Namespace 
			=> XamlConfig.IsUnoXaml ? new NamespaceDeclaration(_unoReader.Namespace) : new NamespaceDeclaration(_systemReader.Namespace);

		public void Dispose() => (XamlConfig.IsUnoXaml ? (IDisposable)_unoReader : _systemReader).Dispose();

		internal bool Read() => XamlConfig.IsUnoXaml ? _unoReader.Read() : _systemReader.Read();
#else
		public object Value => _unoReader.Value;

		public XamlType Type => XamlType.FromType(_unoReader.Type);

		public int LineNumber => _unoReader.LineNumber;

		public int LinePosition => _unoReader.LinePosition;

		public XamlMember Member => XamlMember.FromMember(_unoReader.Member);

		public NamespaceDeclaration Namespace 
			=> new NamespaceDeclaration(_unoReader.Namespace);

		public void Dispose() => (_unoReader as IDisposable).Dispose();

		internal bool Read() => _unoReader.Read();
#endif
	}
}
