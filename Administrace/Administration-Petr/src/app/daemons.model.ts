export class daemons
{
    Id: number;
    idDaemon: number;
    Comment: string;
    LastChecked: DateTimeFormat;
    Tasks: string;
    
   
}

export class Tasks
{
    Id: number;
    idDaemon: number;
    BackupType: number;
    Format:number;
    RepeatInterval:number;
    Sources: Sources;
    Destinations:Destinations;
}

export class Destinations
{
    Id: number;
    IdTask: number
    DestinationType: string;
    DestinationAddress: string;
    DestinationUser: string
    DestinationPassword: string;
    Port: string;
}


export class Sources
{
    Id: number;
    IdTask: number;
    DestinationType: string;
    DestinationAddress: string;
    DestinationUser: string;
    DestinationPassword: string;
    Port: string;

}




