CREATE TABLE [dbo].[Tâche] (
    [Id_tache]    INT           IDENTITY (1, 1) NOT NULL,
    [designation] VARCHAR (250) NOT NULL,
    [priorité]    VARCHAR (50)  NOT NULL,
    [date]        DATETIME          NOT NULL,
    [etat]        VARCHAR (50)  NOT NULL,
    [id_activ]    INT           NULL,
    [id_utilis]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Id_tache] ASC),
    CONSTRAINT [FK_Tâche_ToActivité] FOREIGN KEY ([id_activ]) REFERENCES [dbo].[Activité] ([id_activité]),
    CONSTRAINT [FK_Tâche_ToUtilisateur] FOREIGN KEY ([id_utilis]) REFERENCES [dbo].[Utilisateurs] ([Id_utilisateur])
);

