import { InjectionToken } from "@angular/core";

export let APP_CONFIG = new InjectionToken("app.config");

export interface AppConfig {
    apiEndpoint: string;
    
}

export const AppConfigImpl: AppConfig = {    
     apiEndpoint : "https://localhost:44332",
};