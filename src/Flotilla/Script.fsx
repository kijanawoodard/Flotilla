// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Library1.fs"
open Flotilla
open Raft

// Define your library scripting code here
let test = { CommitIndex=3 ; LastApplied=2 }
follower 2 test.CommitIndex