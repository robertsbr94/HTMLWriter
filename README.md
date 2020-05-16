# HTMLWriter
<h1>C# Class Library used to build HTML files - Incomplete</h1>

<h2>Usage Notes</h2>
<h3>Initialising a HTMLWriter object</h3>
<p>This library can be used to generate HTML documents. To use it, start by initialising a HTML writer object (Constructor takes no parameters).</p>

<b>Example:</b>
<p><pre>var html = new HTMLWriter();</pre></p>

<h3>Adding Attributes</h3>
<p>Some methods have an optional parameter of type: Attribute[], this class should be initialised with two strings, Name and Value, and is always called in a method as an array of Attribute objects.</p>

<b>Example:</b>
<p>Attribute[] parameters should take the form <pre>var attribute = new Attribute[] {new Attribute(style,"font-size:10pt"),new Attribute(class,"StandardParagraph")};</pre></p>

<h3>Methods</h3>
<table>
  <thead>
    <tr>
      <th>Method Name</th>
      <th>Parameters <i>(Optional Parameters in italic)</i></th>
      <th>Functionality</th>
      <th>Example</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>AssignCSS</td>
      <td>string cssPath</td>
      <td>Adds a link to a CSS stylesheet found under cssPath</td>
      <td>html.AssignCSS(@"D:\MainStyle.css");</td>
    </tr>
    <tr>
      <td>AddTitle</td>
      <td>string content</td>
      <td>Assigns a &lt;title&gt; tag to the HTML file</td>
      <td>html.AddTitle("My Webpage");</td>
    </td>
    <tr>
      <td>AddParagraph</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;p&gt; tag to the body of the HTML file</td>
      <td>html.AddParagraph("This is a paragraph.");</td>
    </td>
    <tr>
      <td>AddHeading</td>
      <td>int rank<br>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;h + rank&gt; tag to the body of the HTML file</td>
      <td>html.AddHeading(1, "This adds a h1 tag");</td>
    </td>
    <tr>
      <td>AddBold</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;b&gt; tag to the body of the HTML file</td>
      <td>html.AddBold("This is bold text.");</td>
    </td>
    <tr>
      <td>AddItalic</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;i&gt; tag to the body of the HTML file</td>
      <td>html.AddItalic("This is italic text.");</td>
    </td>
    <tr>
      <td>AddUnderline</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;u&gt; tag to the body of the HTML file</td>
      <td>html.AddUnderline("This is underlined text.");</td>
    </td>
     <tr>
      <td>AddSpan</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;span&gt; tag to the body of the HTML file</td>
      <td>html.AddSpan("This text will be formatted.");</td>
    </td>
    <tr>
      <td>AddDivision</td>
      <td>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds a &lt;div&gt; tag to the body of the HTML file</td>
      <td>html.AddDivision("This text is in a division.");</td>
    </td>
    <tr>
      <td>AddCustomElement</td>
      <td>XmlWriter xmlBody<br>string elementName<br>string content<br><i>Attribute[] attributes</i></td>
      <td>Adds an &lt;elementName&gt; tag to the HTML file<br> <b>Note: xmlBody should be Head or Body specifying where the element should be placed</b></p>
      <td>html.AddCustomElement(Body, pre, "This is preformatted text.");</td>
    </td>
    <tr>
      <td>SaveAsHTML</td>
      <td>string filepath</td>
      <td>Saves the object as a HTML file</td>
      <td>html.SaveAsHTML(@"D:\Index.html");</td>
    </td>
    <tr>
      <td>GetHTMLAsString</td>
      <td></td>
      <td>Returns the content of the HTML file as a string</td>
      <td>html.GetHTMLAsString();</td>
    </td>
  </tbody>
 </table>

<h3>Note: This class is unfinished</h3>
<p>This class is still in development. The following functionality will be added in Release 1.2:-</p>

<ol>
  <li>Add Table elements to HTML</li>
  <li>Add more than one list element to HTML</li>
  <li>Write CSS file</li>
  <li>Specify HTML type</li>
</ol>
