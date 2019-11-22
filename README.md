# miPiace
MiPiace è un sistema per l'acquisizione dei riscontri sul gradimento della qualità del servizio da parte dell'utenza.

Il sistema si compone di due macro-moduli:

* un modulo di backend, nella forma di un servizio REST;
* un modulo frontend, basato sul framework Angular8.

## Schermate

### La schermata principale

![Alt text](docs/images/mainScreen.JPG?raw=true "La schermata principale")

### Il modulo per l'inserimento del dettaglio sul feedback

![Alt text](docs/images/feedbackDetail.JPG?raw=true "Il modulo per il dettaglio sul feedback")

### La schermata finale

![Alt text](docs/images/thanks.JPG?raw=true "La schermata finale")

### La consultazione delle statistiche sui feedback ricevuti

![Alt text](docs/images/statistics.JPG?raw=true "Statistiche sui feedback ricevuti")

### La visualizzazione di dettaglio del feedback ricevuto

![Alt text](docs/images/showFeedbackDetail.JPG?raw=true "Il dettaglio di un feedback")

## Il backend
Il backend è scritto nella tecnologia net core con linguaggio C# ed architettura WebApi. Lo strato di persistenza è basato sul database MongoDB community edition.

L'architettura software del backend è basata sul software [RockApi](https://github.com/supix/rockapi).

## Il frontend
Il frontend è basato sul framework Angular8 e fa uso del linguaggio Typescript.

## Come funziona
L'applicativo MiPiace consente di acquisire un feedback sul livello di gradimento di un servizio
da parte dell'utenza. Nel caso in cui il feedback non sia positivo, il sistema consente altresì di
dettagliare motivazioni e indicare suggerimenti finalizzati al miglioramento della qualità.

Il sistema può gestire feedback per servizi multipli. Attraverso un sistema basato su token, il responsabile di un servizio può creare autonomamente un nuovo questionario sul sistema e divulgare ai suoi utenti il link per la sottomossione del feedback sul gradimento. Il sistema MiPiace acquisisce i feedback classificandoli per singolo servizio e consente la consultazione delle statistiche sui feedback, sempre per singolo servizio. Le statistiche riguardano la media dei feedback calcolata su differenti intervalli temporali. E' possibile anche accedere ai singoli feedback ricevuti. Il numero di servizi gestibili è illimitato.

# License
MiPiace è free software. Il codice sorgente è rilasciato nei termini della licenza AGPL-3.0.

# Disclaimer
Usa questo software a tuo rischio e pericolo. Gli autori declinano qualsiasi responsabilità per l'uso improprio del software e per ogni danno che dovesse derivare dal suo uso.
