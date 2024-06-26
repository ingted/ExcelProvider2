(**
---
title: Getting Started
category: Documentation
categoryindex: 2
index: 1
---
*)


(*** hide ***)
#r "nuget: ExcelProvider"


(**
Getting Started
===========================

To start using ExcelProvider simply reference the ExcelProvider NuGet Package.

<div class="row">
  <div class="span1"></div>
  <div class="span6">
    <div class="well well-small" id="nuget">
      <p>For use in a project, use the following command in the Package Manager Console:</p>
      <pre>PM> Install-Package ExcelProvider</pre>
      <p>For use in an F# script, use the following directive:</p>
      <pre>#r "nuget: ExcelProvider"</pre>
    </div>
  </div>
  <div class="span1"></div>
</div>


After referencing the package, open `FSharp.Interop.Excel`  and you will have access to the Type Provider functionality.

You can create a type for an individual workbook. The simplest option is to specify just the name of the workbook.
You will then be given typed access to the data held in the first sheet.
The first row of the sheet will be treated as field names and the subsequent rows will be treated as values for these fields.

Parameters
----------

When creating the type you can specify the following parameters:

* `FileName` Location of the Excel file.
* `SheetName` Name of sheet containing data. Defaults to first sheet.
* `Range` Specification using `A1:D3` type addresses of one or more ranges. Defaults to use whole sheet.
* `HasHeaders` Whether the range contains the names of the columns as its first line.
* `ForceString` Specifies forcing data to be processed as strings. Defaults to `false`.

All but the first are optional.

The parameters can be specified by position or by using the name - for example the following are equivalent:
*)
open FSharp.Interop.Excel

type MultipleSheets1 = ExcelFile<"MultipleSheets.xlsx", "B">
type MultipleSheets2 = ExcelFile<"MultipleSheets.xlsx", SheetName="B">


(**
Example
-------

This example shows the use of the type provider in an F# script on a sheet containing three rows of data:

![alt text](images/DataTypes.png "Excel sample file with different types")

*)

// reference the type provider
open FSharp.Interop.Excel

// Let the type provider do it's work
type DataTypesTest = ExcelFile<"DataTypes.xlsx">
let file = new DataTypesTest()
let row = file.Data |> Seq.head
let test = row.Float
(** And the variable `test` has the following value: *)
(*** include-value: test ***)
