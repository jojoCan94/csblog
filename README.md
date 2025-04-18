# BlogProject

Un semplice blog creato con ASP.NET Core MVC e Entity Framework Core, pensato per dimostrare le basi delle operazioni CRUD (Create, Read, Update, Delete) nel contesto di un'applicazione web.

## Introduzione

Questo progetto è un esempio pratico per chi vuole imparare a sviluppare un'applicazione web con .NET 9. In particolare, il blog mostra come gestire i post (articoli) utilizzando il pattern MVC e come interfacciarsi con un database tramite Entity Framework Core.  
L'applicazione include le seguenti funzionalità:
- **Create:** Aggiungi nuovi post.
- **Read:** Visualizza la lista dei post e il dettaglio di ciascuno.
- **Update & Delete:** (Da implementare come esercizio per completare il ciclo CRUD.)

## Caratteristiche

- **Struttura MVC:** Separazione tra logica, dati e interfaccia utente.
- **Entity Framework Core:** Gestione dei dati con migrazioni e interazione semplificata con il database (LocalDB per lo sviluppo).
- **Bootstrap:** Layout responsive e componenti stilizzati facilmente tramite classi predefinite.
- **Dotnet Watch / Hot Reload:** Sviluppo rapido senza dover riavviare manualmente il progetto ad ogni modifica.

## Requisiti

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Un editor o IDE per .NET (Visual Studio Code, Visual Studio 2022 ecc...)

## Installazione

1. **Clona la repository:**

   ```bash
   git clone https://github.com/my-username/BlogProject.git
   cd BlogProject
   ```

2. **Ripristina i pacchetti NuGet:**

   ```bash
   dotnet restore
   ```

3. **Configura il database:**

   La stringa di connessione di default, definita in `appsettings.json`, usa LocalDB:
   ```json
   "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogDB;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

## Migrazioni del Database

Per creare lo schema del database ed applicare le modifiche, utilizza i seguenti comandi:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Avvio del Progetto

Per avviare l'applicazione con il supporto per il watch (ricompilazione automatica ad ogni modifica):
```bash
dotnet watch run
```
Il sito sarà disponibile all'indirizzo http://localhost:5181/.

## Struttura del Progetto
- <b>Controllers</b>: Contiene i controller che orchestrano le operazioni sui modelli (es. BlogController).

- **Models**: Definisce le classi del dominio (es. Post.cs).

- **Data**: Include il contesto del database (es. BlogContext.cs).

- **Views**: Contiene le view per il rendering, come `Index.cshtml`, `Details.cshtml`, `Create.cshtml`, ecc.

- **wwwroot**: Directory per file statici (CSS, JS, immagini).

- **appsettings.json**: File di configurazione, dove è definita la stringa di connessione e altre impostazioni.
