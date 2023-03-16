﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_Home_Std.aspx.cs" Inherits="Students_frm_Home_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
<div class="btn-controls">
        <div class="btn-box-row row-fluid">
            <a href="frm_AssignmentsMarks_Std.aspx" class="btn-box big span4"><i class=" icon-paste"></i><b>Assignment's Marks</b>
                <p class="text-muted">
                    Assignments & Marks</p>
            </a><a href="frm_Assignments_Std.aspx" class="btn-box big span4"><i class="icon-book"></i><b>Upload Assignment</b>
                <p class="text-muted">
                    Create New Assignment</p>
            </a><a href="frm_Feedback_Std.aspx" class="btn-box big span4"><i class="icon-money"></i><b>Post Query/Feedback </b>
                <p class="text-muted">
                    Feedback & Queries</p>
            </a>
        </div>
        <div class="btn-box-row row-fluid">
            <div class="span8">
                <div class="row-fluid">
                    <div class="span12">
                        <a href="#" class="btn-box small span4"><i class="icon-briefcase"></i><b>Courses</b>
                        </a><a href="#" class="btn-box small span4"><i class="icon-group"></i><b>About Us</b>
                        </a><a href="#" class="btn-box small span4"><i class="icon-random"></i><b>Year Fall</b>
                        </a>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <a href="#" class="btn-box small span4"><i class="icon-credit-card "></i><b>Why Us?</b>
                        </a><a href="#" class="btn-box small span4"><i class="icon-bullhorn"></i><b>Join Us</b>
                        </a><a href="#" class="btn-box small span4"><i class="icon"></i><b>
                            Location</b> </a>
                    </div>
                </div>
            </div>
            <ul class="widget widget-usage unstyled span4">
                <li>
                    <p>
                        <strong>B.TECH</strong> <span class="pull-right small muted">95%</span>
                    </p>
                    <div class="progress tight">
                        <div class="bar bar-success" style="width: 78%;">
                        </div>
                    </div>
                </li>
                <li>
                    <p>
                        <strong>B.Pharmacy</strong> <span class="pull-right small muted">89%</span>
                    </p>
                    <div class="progress tight">
                        <div class="bar bar-w" style="width: 89%;">
                        </div>
                    </div>
                </li>
                <li>
                    <p>
                        <strong>M.B.A</strong> <span class="pull-right small muted">98%</span>
                    </p>
                    <div class="progress tight">
                        <div class="bar bar-success" style="width: 98%;">
                        </div>
                    </div>
                </li>
                <li>
                    <p>
                        <strong>M.C.A</strong> <span class="pull-right small muted">80%</span>
                    </p>
                    <div class="progress tight">
                        <div class="bar bar-warning" style="width: 80%;">
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>

 </asp:Content>
