namespace Flotilla

module Raft =
    
    type size = int //I'm not sure what I want here; probably int64, but I'd really like uint64
    
    type LogEntry = { Index: size; Term: size; command: byte [] } 
    type ServerTracking = { Peer: string; Index: size }
    
    type PersistantState = {  CurrentTerm: size; VotedFor: string option; Log: LogEntry [] }
    type VolatileState = { CommitIndex: size; LastApplied: size }
    type LeaderState = { NextIndex: ServerTracking []; MatchIndex: ServerTracking [] }

    type AppendEntries = { 
        Term: size; 
        LeaderId: string; 
        PreviousLogIndex: size;
        PreviousLogTerm: size;
        Entries: LogEntry [];
        LeaderCommitIndex: size;
    }
    
    type AppendEntriesResponse = { 
        Term: size;
        Success: bool;
        Reason: string option;
    }

    type RequestVote = { 
        Term: size; 
        CandidateId: string; 
        LastLogIndex: size;
        LastLogTerm: size;        
    }

    type RequestVoteResponse = { 
        Term: size;
        VoteGranted: bool;
        Reason: string option;
    }

    type PreVote = { 
        Term: size; 
        CandidateId: string; 
        LastLogIndex: size;
        LastLogTerm: size;        
    }

    type PreVoteResponse = { 
        Term: size;
        WouldGrantVote: bool;
        Reason: string option;
    }

    let follower state request = 
        state + request