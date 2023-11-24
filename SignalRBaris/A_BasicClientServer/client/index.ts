import * as productViewersWithLoggingHub from "./hubs/productViewersHubWithLogging";
import * as stringParametersFromClientHub from "./hubs/stringParametersFromClientHub";
import * as musicPlayCountFromServerHub from "./hubs/musicPlayCountFromServerHub";
import * as groupsHub from "./hubs/groupsHub";

productViewersWithLoggingHub.configureProductViewersHubWithLogging();
stringParametersFromClientHub.configureStringParametersHub();
musicPlayCountFromServerHub.configureMusicPlayCountFromServerHub();
groupsHub.configureGroupsHub();
