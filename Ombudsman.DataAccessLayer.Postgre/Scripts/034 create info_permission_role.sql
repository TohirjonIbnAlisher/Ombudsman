CREATE TABLE ombudsman.info_permission_role
(
    id integer NOT NULL,
    permission_id integer NOT NULL,
    role_id integer NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT info_permission_role_pkey PRIMARY KEY (id),
    CONSTRAINT permission FOREIGN KEY (permission_id)
        REFERENCES ombudsman.enum_permission (id),
    CONSTRAINT role FOREIGN KEY (role_id)
        REFERENCES ombudsman.enum_role (id),
    CONSTRAINT state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)