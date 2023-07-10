CREATE TABLE ombudsman.enum_sys_table
(
    id integer NOT NULL,
    interface_name character varying NOT NULL,
    sys_table_name character varying NOT NULL,
    CONSTRAINT enum_sys_table_pkey PRIMARY KEY (id)
)