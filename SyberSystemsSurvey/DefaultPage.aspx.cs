// <copyright file="DefaultPage.aspx.cs" company="Adam Litt Test Project.">
// Copyright (c) Adam Litt Test Project.. All rights reserved.
// </copyright>

namespace SyberSystemsSurvey
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Default page.
    /// </summary>
    public partial class DefaultPage : Page
    {
        /// <summary>
        /// Page Load.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">event arguments.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.grd.DataSource = this.GetTableWithInitialData();

                this.grd.DataBind();
            }
        }

        /// <summary>
        /// Populates the table.
        /// </summary>
        /// <returns>a data table for the grid.</returns>
        protected DataTable GetTableWithInitialData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("CircuitName", typeof(string));
            table.Columns.Add("Resistance", typeof(string));
            table.Columns.Add("CircuitType", typeof(string));

            table.Rows.Add("Main ring", 0.125);
            table.Rows.Add("Downstairs Lighting", 0.0);
            table.Rows.Add("Isolated Cooker", 1.4);
            return table;
        }

        /// <summary>
        /// Populates the Circuit types Dropdown.
        /// </summary>
        /// <returns>a list of Circuit types.</returns>
        protected List<ListItem> GetCircuitTypes()
        {
            List<ListItem> dropDownList = new List<ListItem>();

            dropDownList.Add(new ListItem() { Value = "0", Text = "Please Select" });
            dropDownList.Add(new ListItem() { Value = "1", Text = "Type 1" });
            dropDownList.Add(new ListItem() { Value = "2", Text = "Type 2" });

            return dropDownList;
        }

        /// <summary>
        /// Click event for adding a new row.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">event arguments.</param>
        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable dt = this.GetTableWithNoData(); // get select column header only records not required
            DataRow dr;

            foreach (GridViewRow gvr in this.grd.Rows)
            {
                dr = dt.NewRow();

                TextBox txtCircuitName = gvr.FindControl("txtCircuitName") as TextBox;
                TextBox txtResistance = gvr.FindControl("txtResistance") as TextBox;
                TextBox txtCircuitType = gvr.FindControl("txtCircuitType") as TextBox;

                DropDownList circuitTypes = gvr.FindControl("CircuitTypeId") as DropDownList;

                dr[0] = txtCircuitName.Text;
                dr[1] = txtResistance.Text;

                dr[2] = circuitTypes;

                dt.Rows.Add(dr);
            }

            dr = dt.NewRow();
            dt.Rows.Add(dr);

            this.grd.DataSource = dt;
            this.grd.DataBind();
        }

        /// <summary>
        /// returns only structure if the select columns.
        /// </summary>
        /// <returns>table structure for the grid.</returns>
        protected DataTable GetTableWithNoData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CircuitName", typeof(string));
            table.Columns.Add("Resistance", typeof(string));
            table.Columns.Add("CircuitType", typeof(string));
            return table;
        }

        /// <summary>
        /// Data binding event for the main grid for the dropdowns in each row.
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">the event arguments.</param>
        protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var dd = e.Row.Cells[2].Controls[0] as DropDownList;
                if (dd != null)
                {
                    dd.DataSource = this.GetCircuitTypes();

                    dd.DataBind();
                }
            }
        }

        /// <summary>
        /// Event handler for checkbox changed value
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">the event arguments.</param>
        protected void TestPass_CheckedChanged(object sender, EventArgs e)
        {
            // TODO : Wire this up.
        }
    }
}