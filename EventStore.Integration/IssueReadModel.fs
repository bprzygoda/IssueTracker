﻿module IssueTracker.ReadModels.IssueReadModel

open System
open IssueTracker
open IssueTracker.Issue

type IssueReadModel = 
  { Reporter: string;
    Summary: string;
    Status: string;
    TakenBy: string;
    TakenOn: DateTime option;
    ClosedOn: DateTime option;
    CancellationReason: string; }

let apply state = function
    | Reported({Reporter=reporter; Summary=summary}) -> 
        { state with Reporter=reporter; Summary=summary; Status="Reported"}
    | Taken(user, time) ->
        { state with TakenBy=user; TakenOn=Some(time); Status="Active" }
    | Closed(time) ->
        { state with Status="Closed"; }
    | Cancelled(reason) ->
        { state with Status="Cancelled"; }
