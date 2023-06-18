import { configureStore } from '@reduxjs/toolkit'
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux'
import { tweetsReducer } from '../modules/tweets/tweetsSlice'
import { authReducer } from '../modules/auth/authSlice'
import { createEpicMiddleware, combineEpics } from 'redux-observable'
import { authEpics } from '../modules/auth/authEpic'

const rootEpic = combineEpics(
    //@ts-ignore
    authEpics
)
 
const epicMiddleware = createEpicMiddleware();

export const store = configureStore({
    reducer: {
        tweets: tweetsReducer,
        auth: authReducer
    },
    middleware: [epicMiddleware],
    devTools: true, 
  })

  //@ts-ignore
  epicMiddleware.run(rootEpic)

  export type RootState = ReturnType<typeof store.getState>
  export type AppDispatch = typeof store.dispatch
  export const useAppDispatch: () => AppDispatch = useDispatch
  export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector