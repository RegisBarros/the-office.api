﻿using the_office.api.application.Common.Commands;
using the_office.api.application.Seasons.Messaging.Responses;

namespace the_office.api.application.Seasons.Messaging.Requests;

public sealed record RegisterSeasonRequest(int Number, string Title, int TotalEpisodes, 
    DateTime ReleaseDate, string Summary) : ICommand<SeasonResponse>;