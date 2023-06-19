import { Epic, combineEpics, ofType } from "redux-observable";
import { RootState } from "../../store/store";
import { LoginInput, RegisterInput, authActions } from "./authSlice";
import { mergeMap, from, catchError, of } from "rxjs";
import API from '../../client'

export const loginEpic: Epic<ReturnType<typeof authActions.loginAsync>, any, RootState> = (action$) =>
    action$.pipe(
        ofType(authActions.loginAsync.type),
        mergeMap(action =>
            from(API.post<LoginInput, {data: {generatedToken: string, id: string}}>('auth/login', action.payload))
            .pipe(
                mergeMap(response => [
                    authActions.setAuthedUser(response.data)
                ]),
                catchError(error => of())
            ),
            
        )
    )

export const registerEpic: Epic<ReturnType<typeof authActions.registerAsync>, any, RootState> = (action$) =>
    action$.pipe(
        ofType(authActions.registerAsync.type),
        mergeMap(action =>
            from(API.post<RegisterInput>('auth/register', action.payload))
            .pipe(
                mergeMap(() => [
                    authActions.register()
                ]),
                catchError(error => of())
            )
        )
    )

    export const authEpics = combineEpics(
        loginEpic,
        //@ts-ignore
        registerEpic
    )