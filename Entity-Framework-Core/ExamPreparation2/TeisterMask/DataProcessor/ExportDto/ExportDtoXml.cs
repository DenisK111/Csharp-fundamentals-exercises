using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportDtoXml
    {
        [XmlAttribute]
        public int TasksCount { get; set; }
        [XmlElement]
        public string ProjectName { get; set; }
        [XmlElement]
        public string HasEndDate { get; set; }
        [XmlArray]
        public TaskExportDto[] Tasks { get; set; }

    }

    /*<Projects>
      <Project TasksCount="10">
        <ProjectName>Hyster-Yale</ProjectName>
        <HasEndDate>No</HasEndDate>
        <Tasks>
          <Task>
            <Name>Broadleaf</Name>
            <Label>JavaAdvanced</Label>
          </Task>
          <Task>
            <Name>Bryum</Name>
            <Label>EntityFramework</Label>
          </Task>
          <Task>
            <Name>Cornflag</Name>
            <Label>CSharpAdvanced</Label>
          </Task>
          <Task>
            <Name>Crandall</Name>
            <Label>Priority</Label>
          </Task>
          <Task>
            <Name>Debeque</Name>
            <Label>JavaAdvanced</Label>
          </Task>
          <Task>
            <Name>Guadalupe</Name>
            <Label>JavaAdvanced</Label>
          </Task>
          <Task>
            <Name>Guadeloupe</Name>
            <Label>JavaAdvanced</Label>
          </Task>
          <Task>
            <Name>Longbract Pohlia Moss</Name>
            <Label>EntityFramework</Label>
          </Task>
          <Task>
            <Name>Meyen's Sedge</Name>
            <Label>EntityFramework</Label>
          </Task>
          <Task>
            <Name>Pacific</Name>
            <Label>Priority</Label>
          </Task>
        </Tasks>
      </Project>
    */
}
