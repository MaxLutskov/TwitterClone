import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import { TweetType } from '../../components/Tweet'

type AuthState = {
  userId: string,
  token: string
}

export type LoginInput = {
    email: string,
    password: string
}

export type RegisterInput = {
    email: string,
    password: string,
    userName: string
}


const initialState: AuthState= {
    userId: "",
    token: ""
}

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        loginAsync: (state, action: PayloadAction<LoginInput>) => state,
        setAuthedUser: (state, action: PayloadAction<string>) => {
            state.token = action.payload
        },
        registerAsync: (state, action: PayloadAction<RegisterInput>) => state,
        register: (state) => state,
        logout: (state) => {
            state.token = ""
            state.userId = ""
        }
    },
})

export const authActions = authSlice.actions
export const authReducer = authSlice.reducer