﻿using Exiled.API.Features;

namespace Apollyon_plugin.Handlers
{
    class Server
    {
        public void OnWaitingForPlayers()
        {
            Log.Info(message: "En attente de joueurs...");
        }

        public async void OnRoundStarted()
        {
            Log.Info(message: "La partie est lancée !");
            Cassie.MessageTranslated("pitch_.2 .g4 .g4 pitch_0.95 jam_050_02 warning pitch_1 unauthorized jam_050_03 USBdrive access detected . pitch_2 .g1 . . . .g1 . . . .g1 . . .g2 pitch_1 unknown user facility access granted .g1 . . . pitch_.1 .g6 .g6 pitch_.9 jam_085_07 warning pitch_1 breach detected recontainment procedure sequence initiated .g2 all personnel please jam_085_07 evacuate pitch_.85 never pitch_.2 .g3 pitch_1 .g6 .g5 bell_end", "avertissement accès non autorisé au lecteur USB détecté . . . accès accordé à [utilisateur inconnu] . . . Brèche détectée, séquence de la procédure de reconfinement initiée, tout le personnel doit évacuer . . jamais . . .", true, true, true);
        }
    }
}