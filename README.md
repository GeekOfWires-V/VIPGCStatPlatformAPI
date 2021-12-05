# VIPGC Stat Tracking Service

This service API and client was built to replace the existing web client and API by allowing the community to maintain
the necessary information to run its own statistics tracking of community members and built on the principle that
statistics can be added to fit different play styles or recalculated to provide better insight into how a player
performs.

## API

The RESTful Web API is built using ASP.NET Core Web API 2. You can access the live API service at the request of the
players. You can interface with the API to collect information as seen fit.

## Web Client

### Technology

The Web Client is available to preview information at a given point. The client will be written in ASP.NET Core Blazor Webassembly so that the code can be more easily iterated on. Players can access the client to preview information such as public chat logs, public statistics, public  Admins can be registered to access the client and carry out kicks, bans, message broadcasts, and server-wide kicks and other functions.

### Stat Tracking

The client will provide both public and private statistic tracking. Players can pull up server information and preview data such as:

- Weapon
    - Accuracy
    - Kills / Deaths
    - Usage Time
    - Average Usage Time
    - Player Habits
        - What weapon does this usually replace?
        - What weapon usually replaces this?
        - What's the most common sidearm?
        - What's the least common sidearm?
        - % of time that this has an accompanying sidearm
    - Player Stats
      - Player Ranks with Weapon
      - Player Deaths with Weapon (must have qualifying time connected to be included)
- Players
    - Player Score
    - Player Rank
    - "Top" Stats
        - Weapons
            - Best Weapon for Kills
            - Best Weapon for VIP Escorts
            - Best Weapon for VIP Kills
            - Best Weapon for Streaks
            - Worst Weapon for Encounters (Lowest K/D)
        - Maps
            - Best Map for Kills
            - Heatmap for Kills/Deaths
            - Heatmap for VIP Wins/Losses as VIP
            - Heatmap for Round Ending Kills (that are not the VIP)
        - Grenades
            - Live Grenades Shot
            - Kills from Live Grenades Shot
            - Grenade Impact Kills
            - Grenade Impact Deaths
            - Molotov Burn Kills
            - Molotov Burn Deaths
            - Molotov Impact Kills
            - Molotov Impact Deaths
            - Smoke Grenade Launcher Impact Kills
            - Smoke Grenade Launcher Impact Deaths
    - Player-Specific Tracking (**Relies on Steam SSO**)
      - Player Nemesis
      - Player Standing
      - Player Ban Reasons
        - Provides a way for Players to carry out ban appeals so that a denied appeal can prevent any additional spam or appeals
- Maps
  - Global Heat Map for Kills
  - Global Heat Map for Deaths
  - Global Heat Map for VIP Wins
  - Global Heat Map for VIP Losses
  - Global Heat Map for Grenade Explosions
  - Global Heat Map for Grenade Pin Pulls
  - Global Heat Map for Grenade Tosses
  - Player Rankings for the Map based on raw Kills
  - Player Rankings for the Map based on K/D
  - Player Rankings for the Map on Gun-by-Gun basis
- Awards
  - Awards for Activities
    - Top Kills with X Weapon
    - Top K/D overall
    - Most improved
    - Most stagnant for activity density
    - Most time spectating
    - Most Kicked (Tracking non-vote-based kicks)
    - Most Banned (Tracking non-vote-based bans)
  - Separate Awards over Periods of Time

### Administration

Admins will be able to handle administrative tasks through the panel by using services such as:

- Previewing Chat Logs
- Muting Players
  - "Gimping" Players: Prevent text-based chatting
  - "Gagging" Players: Preventing voice-based chatting
  - "Wolf-cry"-marking Players: Preventing players from messaging admins
  - "Silencing" Players: Preventing any public chatting
  - "Isolating" Players: Preventing players from communicating in anyway, including messages to administrators
- Kicking Players
- Banning Players
- Ban Appeals Process
  - Review Ban Appeals
  - Admins mark appeals as Approve/Deny pending review
  - Super Admins/Owners Approve/Deny appeals or reviews
- Delegating/Demoting Player Privileges
  - Make Moderators/Admins
  - Remove Moderators/Admins

## Background Services

### Stat Service

The intent behind this process is to provide a way for Insurgency 2014 to actively communicate information about game sessions in-progress to some form of stat-tracking website so that community members may review information about how a game session has gone, see how they've performed as a player in the community, and understand what they may want to improve upon or what strategies to avoid.

Other methods for connecting from the server to the stat service may happen by making API calls to HTTPS to establish 

### RCON Service

To carry out administrative tasks, the RCON process can be utilized to handle this process since it's the standardized process. If this is not considered the ideal route, a process can be built to produce this data over HTTPS or separate TCP process with secured authentication by simply addressing the API or TCP process with the necessary commands and await responses where required.