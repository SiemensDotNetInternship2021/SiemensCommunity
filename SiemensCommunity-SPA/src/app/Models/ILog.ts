export interface ILog{
    id: number,
    logLevelId:  number,
    logEventId: number,
    logLevel:  string,
    logEvent: string,
    logMessage: string,
    stackTrace: string
}